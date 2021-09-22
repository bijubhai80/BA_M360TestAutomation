CREATE OR REPLACE PACKAGE jbs_create_test_data IS

PROCEDURE CreatePolicy(
    -- These are the values to use when creating the new policy
    -- All values are codes unless their names suggest otherwise.
    p_branch IN varchar2, 
    p_team IN varchar2,
    p_client IN varchar2,
    p_market_segment IN varchar2,
    p_insurance_class IN varchar2,
    p_underwriters IN type_varchar2_100_nt,
    p_locations IN type_varchar2_100_nt,
    p_max_liability IN number,
    p_situation_text IN varchar2,
    p_from_date IN date, 
    p_to_date IN date,
    p_schedule_text IN clob,
    p_broker_1_username IN varchar2,
    -- if this comes back empty, then everything worked.
    p_error_list OUT type_varchar2_4k_nt, 
    -- these identify the newly created policy and version.
    p_policy_id OUT number,  
    p_policy_version_id OUT number,
    p_policy_number OUT number
    );
    
    k_abn varchar2(20) := '32 240 991 395';    

END jbs_create_test_data;  -- End of Spec


CREATE OR REPLACE PACKAGE BODY jbs_create_test_data IS

PROCEDURE AppendError(p_error_list IN OUT type_varchar2_4k_nt, p_error_text IN varchar2);
PROCEDURE ValidateOrgUnits(p_branch IN varchar2, p_team IN varchar2, p_branch_id OUT number, p_team_id OUT number, p_error_list IN OUT type_varchar2_4k_nt);          
PROCEDURE ValidateClient(p_client IN varchar2, p_branch_id IN number, p_client_id OUT number, p_error_list IN OUT type_varchar2_4k_nt);
PROCEDURE ValidateMarketSegAndInsClass(p_market_segment IN varchar2, p_insurance_class IN varchar2, p_team_id IN number, p_market_segment_id OUT number, p_insurance_class_id OUT number, p_error_list IN OUT type_varchar2_4k_nt);
PROCEDURE ValidateLocationIds(p_locations IN type_varchar2_100_nt, p_location_ids OUT type_number28_nt, p_error_list IN OUT type_varchar2_4k_nt);
PROCEDURE ValidateUnderwriters(p_underwriters IN type_varchar2_100_nt, p_team_id IN number, p_insurance_class_id number, p_underwriter_account_ids OUT type_number28_nt, p_error_list IN OUT type_varchar2_4k_nt);

k_prog varchar2(100) := 'JBS_CREATE_TEST.Create_Policy()';
v_debug_all boolean := true;


PROCEDURE CreatePolicy(
    -- These are the values to use when creating the new policy
    -- All values are codes unless their names suggest otherwise.
    p_branch IN varchar2, 
    p_team IN varchar2,
    p_client IN varchar2,
    p_market_segment IN varchar2,
    p_insurance_class IN varchar2,
    p_underwriters IN type_varchar2_100_nt,
    p_locations IN type_varchar2_100_nt,
    p_max_liability IN number,
    p_situation_text IN varchar2,
    p_from_date IN date, 
    p_to_date IN date,
    p_schedule_text IN clob,
    p_broker_1_username IN varchar2,
    -- if this comes back empty, then everything worked.
    p_error_list OUT type_varchar2_4k_nt, 
    -- these identify the newly created policy and version.
    p_policy_id OUT number,  
    p_policy_version_id OUT number,
    p_policy_number OUT number
    ) IS
 
    v_error_list type_varchar2_4k_nt := new type_varchar2_4k_nt();
    v_branch_id number(28); 
    v_team_id number(28);
    v_market_segment_id number(28);
    v_insurance_class_id number(28);
    v_client_id number(28);    
    v_to_date date := p_to_date; 
    v_from_date date := p_from_date;
    v_temp_date date;
    v_location_ids type_number28_nt;
    v_underwriter_ids type_number28_nt;
    v_user_id_1 number(28);
    v_abn varchar2(100);
    v_insured_name varchar2(100);
    v_first_policy_underwriter_id number(28);
    v_underwriter_count number(10);
    v_total_proportion number(7,6);
    v_count number(28); /* re-usable count variable */
    v_debug boolean := v_debug_all or false;

BEGIN
    p_error_list := new type_varchar2_4k_nt();
    
    --START OF VALIDATION--
    --START OF VALIDATION--
    --START OF VALIDATION--
 
    --NOTE: Validation also includes converting codes into ids.

    --Validate To and From Dates.
    if (v_to_date is null and v_from_date is not null) then
        -- to_date defaults to 12 months after from date.
        v_to_date := ADD_MONTHS(p_from_date, 12);                
    elsif (v_from_date > v_to_date) then
        -- Switch from and to date if they are the wrong way around
        v_temp_date := v_from_date;
        v_from_date := v_to_date;
        v_to_date := v_temp_date;
    elsif (v_to_date is null and v_from_date is null) then
        AppendError(p_error_list, 'p_from_date cannot be null.');        
    end if;

    --Validate Max Liability
    if (p_max_liability <= 0 or p_max_liability is null) then 
        AppendError(p_error_list, 'p_max_liability must be a positive integer.');
    end if;

    --Validate Broker 1 name
    select count(*) as num_matches, max(user_id) into v_count, v_user_id_1 from ctl_user u where u.active_yn = 'Y' and username = p_broker_1_username;
    if (v_count = 0) then
        AppendError(p_error_list, 'p_broker_1_username "'|| p_broker_1_username ||'" does not match any active users.');
    elsif (v_count > 1) then
        AppendError(p_error_list, 'p_broker_1_username "'|| p_broker_1_username ||'" matches multiple active users.');
    end if;
        
    --Validate Locations and convert to Ids
    --if v_debug then Common_900.WriteRegardlessToAAA_Debug(k_prog, 41, 'Calling ValidateLocationIds'); end if;
    ValidateLocationIds(p_locations, v_location_ids, p_error_list); 
    --if v_debug then Common_900.WriteRegardlessToAAA_Debug(k_prog, 42, 'Finished ValidateLocationIds and there are ' || p_error_list.COUNT || ' errors.'); end if;
    
    --if v_debug then Common_900.WriteRegardlessToAAA_Debug(k_prog, 11, 'Calling ValidateOrgUnits'); end if;
    --Validate Branch Team and Client first - without these everything fails.    
    ValidateOrgUnits(p_branch, p_team, v_branch_id, v_team_id, p_error_list);
    --if v_debug then Common_900.WriteRegardlessToAAA_Debug(k_prog, 12, 'Finished ValidateOrgUnits and there are ' || p_error_list.COUNT || ' errors.'); end if;

    if (p_error_list.count > 0) then return; end if;

    --if v_debug then Common_900.WriteRegardlessToAAA_Debug(k_prog, 21, 'Calling ValidateClient'); end if;
    ValidateClient(p_client, v_branch_id, v_client_id, p_error_list); 
    --if v_debug then Common_900.WriteRegardlessToAAA_Debug(k_prog, 22, 'Finished ValidateClient and there are ' || p_error_list.COUNT || ' errors.'); end if;

    --Validate Market Segment and Insurance Class for Team and Branch
    --if v_debug then Common_900.WriteRegardlessToAAA_Debug(k_prog, 31, 'Calling ValidateMarketSegAndInsClass'); end if;
    ValidateMarketSegAndInsClass(p_market_segment, p_insurance_class, v_team_id, v_market_segment_id, v_insurance_class_id, p_error_list);
    --if v_debug then Common_900.WriteRegardlessToAAA_Debug(k_prog, 32, 'Finished ValidateMarketSegAndInsClass and there are ' || p_error_list.COUNT || ' errors.'); end if;    
    
    if (p_error_list.count > 0) then return; end if;

    --Validate Underwriter for Market Segment, Branch and Insurance Class
    --if v_debug then Common_900.WriteRegardlessToAAA_Debug(k_prog, 51, 'Calling ValidateUnderwriters'); end if; 
    ValidateUnderwriters(p_underwriters, v_team_id, v_insurance_class_id, v_underwriter_ids, p_error_list);
    --if v_debug then Common_900.WriteRegardlessToAAA_Debug(k_prog, 52, 'Finished ValidateUnderwriters and there are ' || p_error_list.COUNT || ' errors.'); end if;    

    if (p_error_list.count > 0) then return; end if;

    --END OF VALIDATION--
    --END OF VALIDATION--
    --END OF VALIDATION--
    
    --Select some values from the client record
    select nvl(c.abn, k_abn), p.party_name
    into v_abn, v_insured_name
    from jbs_client c
    inner join jbs_party p on p.party_id = c.client_id
    where c.client_id = v_client_id;    
    
    --Insert Policy Record
    insert into jbs_policy 
    (
        policy_id, branch_id, policy_number, client_id, insurance_class_id,
        policy_version_id_current, renewable_yn, policy_status_code, team_id,
        market_segment_id, reinsurance_yn, user_id_1, row_version
    )
    values
    (
        /*policy_id*/ null, v_branch_id, /*policy_number*/ jbs_branchregister_001.getnextpolicynumber(v_branch_id), v_client_id, v_insurance_class_id, 
        /*policy_version_id_current*/ 0, /*renewable_yn*/ 'Y', /*policy_status_code*/ 'I', v_team_id, 
        v_market_segment_id, /*reinsurance_yn*/ 'N', v_user_id_1, /*row_version*/ 1
    )
    returning policy_id, policy_number into p_policy_id, p_policy_number;
    
    --Insert Policy Version Record
    insert into jbs_policy_version
    (
        policy_version_id, policy_id, from_date, to_date, contract_period, version_number, 
        policy_version_type_code, policy_version_status_code, itc, 
        situation_of_risk, insured_abn, client_advised_yn, client_acknowledged_yn, obsolete_components_yn, max_liability_limit, 
        invalid_profile_yn, max_liability_limit_value, 
        insured_name, insured_name_wrap, insured_items,
        created_date, product_version_id, product_auto_rate_yn, calculation_required_yn, layered_yn, 
        client_id, schedule_type, policy_version_id_parent, sd_exempt_nsw, chartered_vessel, 
        underwriter_schedule_id, paid_direct_yn, consolidation_candidate, row_version
    )
    values
    (
        /*policy_version_id*/ p_policy_version_id, p_policy_id, v_from_date, v_to_date, /*contract_period*/ 1, /*version_number*/ 1, 
        /*policy_version_type_code*/ 'N', /*policy_version_status_code*/ 'I', /*itc*/ 100, 
        p_situation_text, v_abn, /*client_advised_yn*/ 'N', /*client_acknowledged_yn*/ 'N', /*obsolete_components_yn*/ 'N', p_max_liability, 
        /*invalid_profile_yn*/ 'N', /*max_liability_limit_value*/ NULL, 
        /*insured_name*/ v_insured_name, /*insured_name_wrap*/ substr(v_insured_name, 1, 50), /*insured_items*/ p_schedule_text, 
        /*created_date*/ sysdate, /*product_version_id*/ NULL, /*product_auto_rate_yn*/ 'N', /*calculation_required_yn*/ 'N', /*layered_yn*/ 'N', 
        v_client_id, /*schedule_type*/ 'TEXT', /*policy_version_id_parent*/ NULL, /*sd_exempt_nsw*/ 'N', /*chartered_vessel*/ NULL, 
        /*underwriter_schedule_id*/ NULL, /*paid_direct_yn*/ 'N', /*consolidation_candidate*/ NULL, /*row_version*/ 1
    )
    returning policy_version_id into p_policy_version_id;
    
    update jbs_policy p
    set policy_version_id_current = p_policy_version_id
    where p.policy_id = p_policy_id
    ;    
    
    insert into jbs_policy_location(policy_version_id, location_id)
    select p_policy_version_id as policy_version_id, locations.column_value as location_id
    from table(v_location_ids) locations
    ;    

    --Insert Policy Underwriter Records - Divide Proportion Evenly Between Them.
    v_underwriter_count := v_underwriter_ids.COUNT;

    insert into jbs_policy_underwriter
    (
        policy_underwriter_id, policy_version_id, underwriter_account_id, 
        lead_yn, proportion, 
        underwriter_type_code, fbcs_member_yn, authorised, lloyds, foreign, 
        policy_number, ultimate_uw_name, ultimate_uw_address, edi_product_id, 
        name, place_of_business, apra_security, policy_number_search, closing_dispatch,
        row_version
    )
    select /*policy_underwriter_id*/ null as policy_underwriter_id, p_policy_version_id, ua.underwriter_account_id, 
        /*lead_yn*/ 'N', /*proportion*/ 1.0 / v_underwriter_count, 
        ua.underwriter_type_code, ua.fbcs_member_yn, ua.authorised, ua.lloyds, ua.foreign, 
        /*policy_number*/ NULL, /*ultimate_uw_name*/ NULL, /*ultimate_uw_address*/ NULL, /*edi_product_id*/ NULL, 
        ua.name, ua.place_of_business, ua.apra_security, /*policy_number_search*/ NULL, /*closing_dispatch*/ 'N',
        /*row_version*/ 1 
    from jbs_underwriter_account ua
    inner join table(v_underwriter_ids) uids on uids.column_value = ua.underwriter_account_id
    ;

    -- Calculate the amount of left-over proportion there is, due to rounding errors.
    -- Grab the id of the first policy_underwriter row whilst we are at it.
    select sum(pu.proportion), min(policy_underwriter_id)
    into v_total_proportion, v_first_policy_underwriter_id
    from jbs_policy_underwriter pu
    where pu.policy_version_id = p_policy_version_id
    ;

    -- Update the extra proportion into the first underwriter, and make it the lead too.
    update jbs_policy_underwriter pu
    set pu.proportion = pu.proportion + (1.0 - v_total_proportion), pu.lead_yn = 'Y'
    where pu.policy_underwriter_id = v_first_policy_underwriter_id
    ; 
    
END CreatePolicy;


PROCEDURE AppendError(p_error_list IN OUT type_varchar2_4k_nt, p_error_text IN varchar2) is
BEGIN
    p_error_list.extend(1);
    p_error_list(p_error_list.last) := p_error_text;
END AppendError;


PROCEDURE ValidateOrgUnits(p_branch IN varchar2, p_team IN varchar2, p_branch_id OUT number, p_team_id OUT number, p_error_list IN OUT type_varchar2_4k_nt) is
    v_exists_count number(28) := 0;
    v_active_count number(28) := 0;
    v_debug boolean := v_debug_all or false;
BEGIN
    select 
        count(*) as exists_count,
        count(case when b.active_yn = 'Y' and t.active_yn = 'Y' then 1 else 0 end) as active_count,
        max(b.branch_id) as branch_id,
        max(t.team_id) as team_id    
    into v_exists_count, v_active_count, p_branch_id, p_team_id 
    from jbs_branch b
    inner join jbs_team t on t.branch_id = b.branch_id
    where b.code = p_branch and t.code = p_team
    ;
    
    if (v_exists_count = 0) then 
        AppendError(p_error_list, 'Either Branch/Office or Team/Dept or both does not exist.');
        return;
    end if;
    
    if (v_active_count = 0) then 
        AppendError(p_error_list, 'Branch/Office "' || p_branch || '" or Team/Dept "' || p_team || '" or both are not active.');
        return;
    end if;
    
    if (v_active_count != 1) then
        AppendError(p_error_list, 'Branch/Office "' || p_branch || '" and Team/Dept "' || p_team || '" matches more than one active branch and/or team.');
        return;
    end if;
    
END ValidateOrgUnits;


PROCEDURE ValidateClient(p_client IN varchar2, p_branch_id IN number, p_client_id OUT number, p_error_list IN OUT type_varchar2_4k_nt) as
    v_exists_count number(10);
    v_active_count number(10); 
    v_branch_code varchar(10);
    v_debug boolean := v_debug_all or false;
BEGIN
    select count(*) as exists_count, 
           count(case when active_yn = 'Y' then 1 else 0 end) as active_count,
           max(client_id) as client_id           
    into v_exists_count, v_active_count, p_client_id
    from jbs_client c
    where c.branch_id = p_branch_id
    and c.code = p_client
    ;

    if (v_active_count = 1) then return; end if;
        
    select code into v_branch_code from jbs_branch where branch_id = p_branch_id;

    if (v_exists_count = 0) then         
        AppendError(p_error_list, 'No client with code "' || p_client || '" exists on the branch "'||v_branch_code||'".');
        return;
    elsif (v_exists_count > 1) then
        AppendError(p_error_list, 'Multiple clients match the code "' || p_client || '" on branch "'||v_branch_code||'".');
        return;
    end if;
    
    if (v_active_count = 0) then 
        AppendError(p_error_list, 'The client "'|| p_client ||'" is not active.');
        return;
    end if;

END ValidateClient; 

PROCEDURE ValidateMarketSegAndInsClass(p_market_segment IN varchar2, p_insurance_class IN varchar2, p_team_id IN number, p_market_segment_id OUT number, p_insurance_class_id OUT number, p_error_list IN OUT type_varchar2_4k_nt) IS
    v_exists_count number(10);
    v_debug boolean := v_debug_all or false;
BEGIN
    --Market Segment
    select count(*), max(ms.market_segment_id) as market_segment_id
    into v_exists_count, p_market_segment_id
    from jbs_market_segment ms
    inner join jbs_team_market_segment tms on tms.market_segment_id = ms.market_segment_id
    where tms.team_id = p_team_id and ms.code = p_market_segment 
          and ms.active_yn = 'Y' and tms.active_yn = 'Y'          
    ;
    
    if (v_exists_count = 0) then 
        AppendError(p_error_list, 'The Market Segment "'|| p_market_segment ||'" is inactive, or not valid for the team.');
    elsif (v_exists_count > 1) then
        AppendError(p_error_list, 'The Market Segment "'|| p_market_segment ||'" matches multiple market segments.  Something is wrong.');
    end if;

    --Insurance Class
    select count(*), max(insurance_class_id)
    into v_exists_count, p_insurance_class_id
    from jbs_insurance_class ic    
    where ic.code = p_insurance_class and ic.active_yn = 'Y'
    ;

    if (v_exists_count = 0) then 
        AppendError(p_error_list, 'The Insurance Class "'|| p_insurance_class ||'" is inactive, or does not exist.');
    elsif (v_exists_count > 1) then
        AppendError(p_error_list, 'The Insurance Class code "'|| p_insurance_class ||'" matches multiple insurance classes.  Something is wrong.');
    end if;    
    
END;


PROCEDURE ValidateLocationIds(p_locations IN type_varchar2_100_nt, p_location_ids OUT type_number28_nt, p_error_list IN OUT type_varchar2_4k_nt) IS
    v_total_count number(10);
    v_distinct_count number(10);
    v_unknown_count number(10);
    v_debug boolean := v_debug_all or false;
    v_debug_temp varchar2(1000);
BEGIN
    if v_debug then
        Common_900.WriteRegardlessToAAA_Debug(k_prog, 'VLOC-11', 'Commencing ValidateLocationIds.');
        select listagg(column_value, ', ') within group(order by 1) into v_debug_temp from table(p_locations);        
        Common_900.WriteRegardlessToAAA_Debug(k_prog, 'VLOC-11', 'Location list is: ' || v_debug_temp || '.');
    end if;

--    select count(lp.column_value) over (partition by 1) as total_count, 
--           count(distinct lp.column_value) over (partition by 1) as distinct_count,
--           count(case when lp.column_value is null then 1 else 0 end) over (partition by 1) as unknown_count
    select count(lp.column_value) as total_count, 
           count(distinct lp.column_value) as distinct_count,
           count(case when lp.column_value is null then 1 else 0 end) as unknown_count
    into v_total_count, v_distinct_count, v_unknown_count    
    from jbs_location l
    left outer join table(p_locations) lp /*location parameters*/ on upper(lp.column_value) = l.code
    ;
    
    if (v_distinct_count < 1) then 
        AppendError(p_error_list, 'No valid locations given for the policy.');
        return;
    end if;
    
    if (v_distinct_count != v_total_count) then
        AppendError(p_error_list, 'Location list contains duplicates.');
        return;
    end if;
    
    select l.location_id
    bulk collect into p_location_ids    
    from jbs_location l
    inner join table(p_locations) lp /*location parameters*/ on upper(lp.column_value) = l.code
    ;
    
    if v_debug then 
        Common_900.WriteRegardlessToAAA_Debug(k_prog, 'VLOC-21', 'Finished ValidateLocationIds');
        select listagg(column_value, ', ') within group(order by 1) into v_debug_temp from table(p_location_ids);        
        Common_900.WriteRegardlessToAAA_Debug(k_prog, 'VLOC-22', 'Translated locations into ids: ' || v_debug_temp || '.');        
    end if;
    
END ValidateLocationIds;

PROCEDURE ValidateUnderwriters(p_underwriters IN type_varchar2_100_nt, p_team_id IN number, p_insurance_class_id number, p_underwriter_account_ids OUT type_number28_nt, p_error_list IN OUT type_varchar2_4k_nt) IS
    v_total_count number(10);
    v_distinct_count number(10);
    v_unknown_count number(10);
    v_valid_count number(10);
    v_invalid_underwriters varchar2(4000);
    v_insurance_class_code varchar2(10);
    v_debug_temp varchar2(1000);
    v_valid boolean := true;
    v_debug boolean := v_debug_all or false;
BEGIN
    if v_debug then 
        Common_900.WriteRegardlessToAAA_Debug(k_prog, 'VU-11', 'ValidateUnderwriters Commences.');
        Common_900.WriteRegardlessToAAA_Debug(k_prog, 'VU-12', 'p_underwriters contains ' || p_underwriters.COUNT || ' values.');
        select listagg(u.column_value, ', ') within group(order by 1) as underwriters into v_debug_temp from table(p_underwriters) u; 
        Common_900.WriteRegardlessToAAA_Debug(k_prog, 'VU-13', 'p_underwriters = ' || v_debug_temp); 
    end if;
    
    select count(up.column_value) as total_count, 
           count(distinct up.column_value) as distinct_count,
           count(ua.underwriter_account_id) as valid_count
    into v_total_count, v_distinct_count, v_valid_count    
    from table(p_underwriters) up /*underwriter parameters*/
    left outer join jbs_underwriter_account ua on ua.code = upper(up.column_value)
    ;

    if v_debug then 
        Common_900.WriteRegardlessToAAA_Debug(k_prog, 'VU-21', 'v_total_count = ' || v_total_count);
        Common_900.WriteRegardlessToAAA_Debug(k_prog, 'VU-22', 'v_distinct_count = ' || v_distinct_count);
        Common_900.WriteRegardlessToAAA_Debug(k_prog, 'VU-23', 'v_valid_count = ' || v_valid_count);
    end if;

    if (v_valid_count < v_total_count) then
        AppendError(p_error_list, 'Some underwriter account codes were not recognised.');
        v_valid := false;
    end if;
    
    if (v_distinct_count < 1) then 
        AppendError(p_error_list, 'No valid underwriters were given for the policy.');
        v_valid := false;
    end if;
    
    if (v_distinct_count < v_total_count) then
        AppendError(p_error_list, 'The underwriter list contains duplicates, please remove them.');
        v_valid := false;
    end if;

    if (v_valid != true) then return; end if;
         
    select ua.underwriter_account_id
    bulk collect into p_underwriter_account_ids    
    from jbs_underwriter_account ua
    inner join table(p_underwriters) up /*underwriter parameters*/ on upper(up.column_value) = ua.code
    ;
    
    -- Test underwriters actually cover the given insurance class
    with uw_account_and_ho as
    (
        select ua.underwriter_account_id, uho.underwriter_head_office_id
        from jbs_underwriter_account ua
        inner join jbs_underwriter_branch ub on ub.underwriter_branch_id = ua.underwriter_branch_id
        inner join jbs_underwriter_head_office uho on uho.underwriter_head_office_id = ub.underwriter_head_office_id
    ),
    uw_account_vs_insurance_class as
    (
        select distinct ic.insurance_class_id, uaho.underwriter_account_id, ic.code as insurance_class_code
        from jbs_insurance_class ic
        inner join jbs_underwriter_cover_class ucc on ucc.insurance_class_id is null or ucc.insurance_class_id = ic.insurance_class_id
        inner join uw_account_and_ho uaho on uaho.underwriter_account_id = ucc.underwriter_account_id or uaho.underwriter_head_office_id = ucc.underwriter_head_office_id
    )
    select count(case when uavic.underwriter_account_id is null then 0 else 1 end) as valid_count,
           listagg(case when uavic.underwriter_account_id is null then ua.code else null end, ', ') within group(order by 1) as invalid_underwriter_codes           
    into v_valid_count, v_invalid_underwriters
    from table(p_underwriter_account_ids) uai
    inner join jbs_underwriter_account ua on ua.underwriter_account_id = uai.column_value 
    left outer join uw_account_vs_insurance_class uavic on uavic.underwriter_account_id = uai.column_value and uavic.insurance_class_id = p_insurance_class_id        
    ;
    
    if (v_valid_count != p_underwriter_account_ids.COUNT) then
         select code into v_insurance_class_code from jbs_insurance_class where insurance_class_id = p_insurance_class_id;
         AppendError(p_error_list, p_underwriter_account_ids.COUNT || ' underwriter accounts were given, but only ' || v_valid_count || ' of them write policies for the given insurance class...');
         AppendError(p_error_list, 'Underwriter accounts ' || v_invalid_underwriters || ' do not write policies for class "'|| v_insurance_class_code ||'".');
         return;
    end if;
    
END ValidateUnderwriters;


END jbs_create_test_data;  -- End of package

