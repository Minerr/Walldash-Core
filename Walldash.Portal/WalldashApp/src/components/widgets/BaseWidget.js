import React, { useState, useContext, useEffect } from "react";
import SingleMetric from "./SingleMetric";
import { WidgetContext } from "../../contexts/WidgetContext";
import RankChart from "./RankChart";
import WidgetForm from "./forms/WidgetForm";
import ButtonEdit from "../patials/ButtonEdit";
import Graph from "./Graph";

const BaseWidget = ({ widget }) => {
  const [edit, setEdit] = useState(false);
  const { dispatch } = useContext(WidgetContext);

  useEffect(() => {
    refreshWidget();
  }, []);

  const refreshWidget = () => {
    if (!widget.metricAlias) {
      return;
    }

    dispatch({
      type: "REFRESH_WIDGET",
      id: widget.id,
      metricAlias: widget.metricAlias
    });
  };

  const selectWidget = () => {
    switch (widget.type) {
      case "SingleData":
        return <SingleMetric key={widget.id} widget={widget} />;
      case "Graph":
        return <Graph key={widget.id} widget={widget} />;
      case "Rank":
        return <RankChart key={widget.id} widget={widget} />;
      default:
        return "";
    }
  };

  const { width, height, backgroundColor, textColor } = widget;
  return (
    <div
      className='base-widget'
      style={{
        gridColumn: `span ${width}`,
        gridRow: `span ${height}`,
        paddingTop: `calc(100% / ${width}`,
        backgroundColor: backgroundColor,
        color: textColor
      }}>
      <div className='aspec-ratio'>{selectWidget()}</div>
      <ButtonEdit onClick={() => setEdit(true)} />
      {edit ? (
        <WidgetForm onClose={() => setEdit(false)} widget={widget} />
      ) : (
        ""
      )}
    </div>
  );
};

export default BaseWidget;
