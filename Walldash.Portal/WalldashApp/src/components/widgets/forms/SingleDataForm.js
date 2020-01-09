import React, { useState, useEffect } from "react";
import ApiClient from "../../../api/ApiClient";
import CustomInput from "./CustomInput";
import CustomSelect from "./CustomSelect";

const SingleDataForm = ({ onChange, widget }) => {
  const [metricAliases, setMetricAliases] = useState([]);

  useEffect(() => {
    ApiClient.getMetricAliases().then(response => {
      setMetricAliases(response);
    });
  }, []);

  return (
    <div className='single-data-form'>
      <CustomInput
        label='Title'
        value={widget.alias}
        onChange={e => onChange({ alias: e.target.value })}
        placeholder='Insert title'
        required={true}
      />
      <CustomSelect
        label='Metric'
        value={widget.metricAlias}
        onChange={e => onChange({ metricAlias: e.target.value })}
        options={metricAliases}
        required={true}
      />
    </div>
  );
};

export default SingleDataForm;
