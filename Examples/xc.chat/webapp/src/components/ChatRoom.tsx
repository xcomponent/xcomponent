import * as React from "react";
import * as Component from "react";
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

const mapStateToProps = (state, ownProps) => {
    return {
        messages: state.chatRoom.messages,
    };
};

const mapDispatchToProps = (dispatch) => {
    return {};
};


class ChatRoom extends React.Component<any, any> {
    bottom: Paragraph;

    render() {
        let messagesDisplay = [];

        if (this.props.messages) {
            messagesDisplay.push(
                Array.from(this.props.messages).map((message) => {
                    return (
                        <Paragraph margin="none">{message}</Paragraph>
                    );
                })
            );
        }
        return (
            <Article>
                {messagesDisplay}
                <Paragraph margin="none" ref={(el) => { this.bottom = el; }}/>
            </Article>
        );
    }

    componentDidUpdate(prevProps, prevState) {
        const node = ReactDOM.findDOMNode(this.bottom);
        node.scrollIntoView({ behavior: "smooth" });
    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(ChatRoom);