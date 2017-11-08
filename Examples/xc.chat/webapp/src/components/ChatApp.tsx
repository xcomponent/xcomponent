import * as React from "react";
import * as App from "grommet/components/App";
import * as Box from "grommet/components/Box";
import * as Split from "grommet/components/Split";
import { connect } from "react-redux";
import NavSideBar from "components/NavSideBar";
import AppHeader from "components/AppHeader";
import AppFooter from "components/AppFooter";

const mapStateToProps = (state, ownProps) => {
    return {
        navActive: state.nav.active
    };
};

let ChatApp: any = ({ navActive, children }) => {

    let nav;
    if (navActive) {
        nav = <NavSideBar />;
    }

    return (
        <App centered={false}>
            <Split flex="right" >
                {nav}
                <Box full={true}>
                    <AppHeader />
                    <Box flex={true} justify="between">
                        {children}
                    </Box>
                    <AppFooter/>
                </Box>
            </Split>
        </App>
    );
};

ChatApp = connect(
    mapStateToProps
)(ChatApp);

export default ChatApp;