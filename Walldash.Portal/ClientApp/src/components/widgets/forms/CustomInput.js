import React from "react";

const CustomInput = ({ label, placeholder = "", onChange, value, required = false }) => {
  return (
    <React.Fragment>
      <label>{label}</label>
      <input placeholder={placeholder} onChange={onChange} value={value} required={required} />
    </React.Fragment>
  );
};

export default CustomInput;
