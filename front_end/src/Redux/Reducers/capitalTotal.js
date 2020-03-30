import { handleActions } from "redux-actions";
import { getCapitalTotalSuccess, handleError } from "../actions";

export default handleActions(
  {
    [getCapitalTotalSuccess]: (state, action) => {
      return action.payload;
    },
    [handleError]: (state, action) => {
      return console.log("Ocurrio un error");
    }
  },
  []
);
