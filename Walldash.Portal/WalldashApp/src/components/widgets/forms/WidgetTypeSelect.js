import React from "react";

const WidgetTypeSelect = ({ onSelectWidgetType, selectedType }) => {
  const widgetTypes = ["SingleData", "Graph", "PieChart", "Rank"];

  return (
    <div className='widget-type-select'>
      {widgetTypes.map(type => {
        return (
          <div
            className={`widget-type ${selectedType === type ? "active" : ""}`}
            key={type}
            onClick={() => onSelectWidgetType(type)}>
            {type}
          </div>
        );
      })}
    </div>
  );
};

export default WidgetTypeSelect;
