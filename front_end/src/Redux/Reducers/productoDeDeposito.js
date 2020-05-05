import { handleActions } from "redux-actions";
import { getProductosDepositoSuccess } from "../actions";

export default handleActions(
  {
    [getProductosDepositoSuccess]: (state, action) => {
      return action.payload;
    },
   
  },
  []
);
