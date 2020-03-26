import { handleActions } from "redux-actions";
import { getProductosTerminadosSuccess, handleError } from "../actions";

export default handleActions(
  {
    [getProductosTerminadosSuccess]: (state, action) => {
      return action.payload;
    },
    [handleError]: (state, action) => {
      return console.log("Ocurrio un error");
    }
  },
  []
);
