import React from "react";
import { ResponsiveContainer, ComposedChart, Line, Area, Bar, XAxis, YAxis, Legend, CartesianGrid } from "recharts";
import moment from "moment";

const graph = {
  id: "1",
  type: "Graph",
  alias: "Graph Title",
  metricAlias: "turnover",
  styleSettings: {
    backgroundColor: "#ffffff",
    textColor: "#55698c"
  },
  width: 2,
  height: 1,
  graphType: "line",
  graphValueX: "timestamp",
  graphValueY: "number",
  graphColor: "#8884d8"
};

const Graph = ({ widget }) => {
  const renderComponent = () => {
    switch (widget.graphType) {
      case "line":
        return <Line type='monotone' dataKey={widget.graphValueY} stroke={widget.graphColor} />;
      case "area":
        return (
          <Area
            type='monotone'
            dataKey={widget.graphValueY}
            strokeWidth={2}
            fill={widget.graphColor}
            stroke={widget.graphColor}
          />
        );
      case "bar":
        return <Bar dataKey={widget.graphValueY} barSize={20} fill={widget.graphColor} />;

      default:
        break;
    }
  };

  if (!widget.metricData) {
    return "loading";
  }

  return (
    <div className='graph'>
      <div className='title'>{widget.alias}</div>
      <ResponsiveContainer>
        <ComposedChart
          width={500}
          height={400}
          data={widget.metricData}
          margin={{
            top: 128,
            right: 64,
            bottom: 32,
            left: 32
          }}>
          <CartesianGrid stroke='#ffffff0d' />
          <XAxis
            dataKey={widget.graphValueX}
            stroke={widget.color}
            tick={{ fill: graph.styleSettings.textColor }}
            tickFormatter={unixTime => moment(unixTime).format("HH:mm")}
          />
          <YAxis stroke={graph.styleSettings.textColor} tick={{ fill: graph.styleSettings.textColor }} />
          <Legend />
          {renderComponent()}
        </ComposedChart>
      </ResponsiveContainer>
    </div>
  );
};

export default Graph;
