import { handleActions } from "redux-actions";
import { getProductosDeCompraSuccess } from "../actions";

export default handleActions(
  {
    [getProductosDeCompraSuccess]: (state, action) => {
      return action.payload;
    },
  },
  []
);