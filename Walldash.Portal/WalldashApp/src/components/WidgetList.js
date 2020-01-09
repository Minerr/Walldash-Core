import React, { useContext } from "react";
import { WidgetContext } from "../contexts/WidgetContext";
import NewWidgetButton from "./NewWidgetButton";
import BaseWidget from "./widgets/BaseWidget";

const WidgetList = () => {
  const { widgets } = useContext(WidgetContext);

  const renderList = () => {
    return widgets.map(widget => {
      return <BaseWidget key={widget.id} widget={widget} />;
    });
  };

  return (
    <div className='widget-list'>
      {widgets.length > 0 ? renderList() : ""}
      <NewWidgetButton />
    </div>
  );
};

export default WidgetList;
