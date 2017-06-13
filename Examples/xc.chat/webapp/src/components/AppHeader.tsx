import * as React from "react";
import * as Header from "grommet/components/Header";
import * as Title from "grommet/components/Title";
import * as Label from "grommet/components/Label";
import * as Button from "grommet/components/Button";
import { connect } from "react-redux";
import { navActivate } from "actions";
import Logo from "components/Logo";
import * as Box from "grommet/components/Box";
import * as Image from "grommet/components/Image";
import * as Heading from "grommet/components/Heading";
import { FormattedMessage } from "react-intl";

const mapStateToProps = (state, ownProps) => {
    return {
        navActive: state.nav.active
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
        onMenuIconClick: () => {
            dispatch(navActivate(true));
        }
    };
};

let AppHeader = ({navActive, onMenuIconClick}) => {
    const navTitle = <Heading><FormattedMessage id="app.title" /></Heading>;
    let navLogo;
    if (!navActive) {
        navLogo = <Button plain={true} onClick={onMenuIconClick}><Logo /></Button>;
    }

    return (
        <Header
            fixed={true}
            direction="row"
            justify="between"
            pad={{ horizontal: "medium" }}>
            <Title>
                {navLogo}
            </Title>

            <Box align="center" flex={true} justify="center">{navTitle}</Box>

            <Image src={require("../resources/logo_xc.png")} size="small" />

        </Header>
    );
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(AppHeader);