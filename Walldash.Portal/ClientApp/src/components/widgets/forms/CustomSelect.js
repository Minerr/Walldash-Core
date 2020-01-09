import React from "react";

const CustomSelect = ({ label, onChange, value, options, required = false }) => {
  return (
    <React.Fragment>
      <label>{label}</label>
      <select onChange={onChange} value={value} required={required}>
        {options.map(option => {
          return (
            <option value={option} key={option}>
              {option}
            </option>
          );
        })}
      </select>
    </React.Fragment>
  );
};

export default CustomSelect;
