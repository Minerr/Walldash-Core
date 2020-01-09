import React from "react";
import { ResponsiveContainer, ComposedChart, Line, Area, Bar, XAxis, YAxis, Legend, CartesianGrid } from "recharts";
import moment from "moment";

const ComposedGraph = ({ widget, edit, onCancel, onEdit, onRemove }) => {
  const renderEdit = () => {
    return <div>Edit</div>;
  };

  const renderComponent = () => {
    return widget.widgetSettings.components.map((component, i) => {
      switch (component.componentType) {
        case "line":
          return <Line key={i} type='monotone' dataKey={component.dataKey} stroke={component.color} />;
        case "area":
          return (
            <Area
              key={i}
              type='monotone'
              dataKey={component.dataKey}
              strokeWidth={2}
              fill={component.color}
              stroke={component.color}
            />
          );
        case "bar":
          return <Bar key={i} dataKey={component.dataKey} barSize={20} fill={component.color} />;
        default:
          return "";
      }
    });
  };

  const renderDisplay = () => {
    const { metricData, colorSettings } = widget;

    if (metricData.length < 1) {
      return;
    }

    return (
      <div style={{ width: "100%", height: "100%" }}>
        <ResponsiveContainer>
          <ComposedChart
            width={500}
            height={400}
            data={metricData}
            margin={{
              top: 32,
              right: 32,
              bottom: 16,
              left: 0
            }}>
            <CartesianGrid stroke='#ffffff0d' />
            <XAxis
              dataKey='timestamp'
              stroke={colorSettings.textColor}
              tick={{ fill: colorSettings.textColor }}
              tickFormatter={unixTime => moment(unixTime).format("HH:mm Do")}
            />
            <YAxis stroke={colorSettings.textColor} tick={{ fill: colorSettings.textColor }} />
            <Legend />
            {renderComponent()}
          </ComposedChart>
        </ResponsiveContainer>
      </div>
    );
  };

  return <div className='composed-graph'>{edit ? renderEdit() : renderDisplay()}</div>;
};

export default ComposedGraph;
