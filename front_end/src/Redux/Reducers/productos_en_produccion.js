import { handleActions } from "redux-actions";
import { getProductosEnProduccionSuccess, handleError } from "../actions";

export default handleActions(
  {
    [getProductosEnProduccionSuccess]: (state, action) => {
      return action.payload;
    },
    [handleError]: (state, action) => {
      return console.log("Ocurrio un error");
    }
  },
  []
);
