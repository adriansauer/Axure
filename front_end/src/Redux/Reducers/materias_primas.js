import { handleActions } from "redux-actions";
import { getMateriasPrimasSuccess, handleError } from "../actions";

export default handleActions(
  {
    [getMateriasPrimasSuccess]: (state, action) => {
     

      return action.payload;
    },
    [handleError]: (state, action) => {
      return console.log("Ocurrio un error");
    }
  },
  []
);
