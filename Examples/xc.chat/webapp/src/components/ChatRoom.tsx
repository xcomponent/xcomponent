import * as React from "react";
import * as Label from "grommet/components/Label";
import * as Box from "grommet/components/Box";
import * as Section from "grommet/components/Section";
import * as Footer from "grommet/components/Footer";
import *  as TextInput from "grommet/components/TextInput";
import *  as Button from "grommet/components/Button";
import *  as Paragraph from "grommet/components/Paragraph";
import * as Article from "grommet/components/Article";
import { connect } from "react-redux";
import { FormattedDate, FormattedMessage, defineMessages, injectIntl, InjectedIntl } from "react-intl";
import * as ReactDOM from "react-dom";
import Scroller from "react-scroll-collapse";

const mapStateToProps = (state, ownProps) => {
    return {
        messages: state.chatRoom.messages,
    };
};

const mapDispatchToProps = (dispatch) => {
    return {};
};

const ChatRoom = ({messages}) => {
    let messagesDisplay = [];

    if (messages) {
        messagesDisplay.push(
            Array.from(messages).map((message) => {
                return (
                    <Paragraph margin="none">{message}</Paragraph>
                );
            })
        );
    }
    return (
        <Scroller>
            <Article>
                {messagesDisplay}
            </Article>
        </Scroller>
    );
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(ChatRoom);