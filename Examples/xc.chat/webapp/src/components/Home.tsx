import * as React from "react";
import * as Label from "grommet/components/Label";
import { connect } from "react-redux";
import PageHeader from "components/PageHeader";
import ChatRoom from "components/ChatRoom";
import * as Box from "grommet/components/Box";
import Table from "grommet/components/Table";
import { FormattedDate, FormattedMessage, defineMessages, injectIntl, InjectedIntl } from "react-intl";

interface HomeProps {
    intl: InjectedIntl;
}

const mapStateToProps = (state, ownProps) => {
    return {
        selectedRoom: state.chatRoom.selectedRoom
    };
};

const mapDispatchToProps = (dispatch) => {
    return {};
};

const Home = ({ selectedRoom }) => {
    if (selectedRoom !== "") {
        return (
            <div>
                <PageHeader title={selectedRoom} />
                <ChatRoom/>
            </div>
        );
    }
    else {
        return (
            <div>
                <PageHeader title="Login" />
                    Test
            </div>
        );
    }
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(Home);