import * as React from "react";
import * as Box from "grommet/components/Box";
import * as Label from "grommet/components/Label";
import *  as TextInput from "grommet/components/TextInput";
import { connect } from "react-redux";
import { sendMessage } from "coreListener";

const mapStateToProps = (state, ownProps) => {
    return {
        connected: state.chatRoom.settings.login !== "",
        sendMessage: (message: string) => {
            if (message && message !== "") {
                sendMessage(state.chatRoom.selectedRoom, state.chatRoom.settings.login, message, state.chatRoom.settings.host, state.chatRoom.settings.port);
            }
        },
    };
};

const mapDispatchToProps = (dispatch) => {
    return {};
};

const AppFooter = ({sendMessage, connected}) => {
    let sendMessageTextInput;

    if (connected) {
        sendMessageTextInput = <TextInput id="message" onKeyDown={ (evt) => {
                let code = evt.charCode || evt.keyCode;
                if (code === 13) {
                    sendMessage(evt.target.value);
                    evt.target.value = "";
                }
                }}
            />;
    }

    return <Box appCentered={true} direction="row" colorIndex="brand" reverse={true}>
            <Box direction="row" pad="small">
                <Label margin="none">powered by : <a href="http://www.xcomponent.com" target="_blank">XComponent</a></Label>
            </Box>
            {sendMessageTextInput}
    </Box>;
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(AppFooter);