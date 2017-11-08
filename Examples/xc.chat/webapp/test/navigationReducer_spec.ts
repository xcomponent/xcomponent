import * as deepFreeze from "deep-freeze";
import { navigation } from "../src/reducers/navigation";
import { navActivate } from "../src/actions/navigation";

const testActivate = (beforeStatus: boolean, actionStatus: boolean) => {

        const stateBefore = { active: beforeStatus };
        const action = navActivate(actionStatus);
        const stateAfter = {
            active: actionStatus
        };

        deepFreeze(stateBefore);
        deepFreeze(action);

        expect(
            navigation(stateBefore, action)
        ).toEqual(stateAfter);
    };

test("When a NAV_ACTIVATE action with a true status is received, the nav state should become activated", () => {
    testActivate(false, true);
});

test("When a NAV_ACTIVATE action with a false status is received, the nav state should become deactivated", () => {
    testActivate(true, false);
});