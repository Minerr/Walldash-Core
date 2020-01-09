import React from "react";

const SingleMetric = ({ widget }) => {
  const render = () => {
    return (
      <div className='single-metric'>
        <div className='display'>
          <div className='title'>{widget.alias}</div>
          <div className='number'>
            {widget.metricData ? (widget.metricData[0] ? widget.metricData[0].number : "loading") : "loading"}
          </div>
        </div>
      </div>
    );
  };

  return render();
};

export default SingleMetric;
