import React from "react";
import ButtonEdit from "../patials/ButtonEdit";

const RankChart = ({ widget, edit, onCancel, onEdit, onRemove }) => {
  return (
    <div className='rank-chart'>
      <div className='title'>{widget.title}</div>
      <div className='list'>
        <ul>
          <li>hej</li>
          <li>med</li>
          <li>dig</li>
        </ul>
      </div>
      <ButtonEdit />
    </div>
  );
};

export default RankChart;
