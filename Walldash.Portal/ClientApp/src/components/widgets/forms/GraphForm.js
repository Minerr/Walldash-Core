import React, { useState, useEffect } from "react";
import ApiClient from "../../../api/ApiClient";
import CustomInput from "./CustomInput";
import CustomSelect from "./CustomSelect";
import ColorPicker from "../../patials/ColorPicker";

const GraphForm = ({ onChange, widget }) => {
  const [metricAliases, setMetricAliases] = useState([]);

  const graphTypes = ["line", "area", "bar"];

  const HARDCODED = ["timestamp", "number"];

  useEffect(() => {
    ApiClient.getMetricAliases().then(response => {
      setMetricAliases(response);
    });
  }, []);

  return (
    <div className='graph-form'>
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
      <CustomSelect
        label='Graph Type'
        value={widget.graphType}
        onChange={e => onChange({ graphType: e.target.value })}
        options={graphTypes}
        required={true}
      />
      <CustomSelect
        label='X Axis'
        value={widget.graphValueX ? widget.graphValueX : HARDCODED[0]}
        onChange={e => onChange({ graphValueX: e.target.value })}
        options={HARDCODED}
        required={true}
      />
      <CustomSelect
        label='Y Axis'
        value={widget.graphValueY ? widget.graphValueY : HARDCODED[0]}
        onChange={e => onChange({ graphValueY: e.target.value })}
        options={HARDCODED}
        required={true}
      />
      <label>Graph Color</label>
      <ColorPicker color={widget.graphColor} onChange={color => onChange({ graphColor: color })} />
    </div>
  );
};

export default GraphForm;
