import { handleActions } from "redux-actions";
import { getProductosSuccess } from "../actions";

export default handleActions(
  {
    [getProductosSuccess]: (state, action) => {
      return action.payload;
    },
  },
  []
);
