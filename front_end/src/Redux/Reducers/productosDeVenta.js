import { handleActions } from "redux-actions";
import { getProductosDeVentaSuccess } from "../actions";

export default handleActions(
  {
    [getProductosDeVentaSuccess]: (state, action) => {
      return action.payload;
    },
  },
  []
);