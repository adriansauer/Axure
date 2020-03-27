import { handleActions } from "redux-actions";
import { getCapitalDepositoSuccess, handleError } from "../actions";

export default handleActions(
  {
    [getCapitalDepositoSuccess]: (state, action) => {
      return action.payload;
    },
    [handleError]: (state, action) => {
      return console.log("Ocurrio un error");
    }
  },
  []
);
