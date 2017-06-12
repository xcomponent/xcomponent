import * as React from "react";
import * as Box from "grommet/components/Box";
import * as Label from "grommet/components/Label";
import *  as TextInput from "grommet/components/TextInput";
import { connect } from "react-redux";
import { sendMessage } from "coreListener";

const mapStateToProps = (state, ownProps) => {
    return {
        sendMessage: (message: string) => {
            sendMessage(state.chatRoom.selectedRoom, "Toto", message);
        },
    };
};

const mapDispatchToProps = (dispatch) => {
    return {};
};

const AppFooter = ({sendMessage}) => (
    <Box appCentered={true} direction="row" colorIndex="brand" reverse={true}>
            <Box direction="row" pad="small">
                <Label margin="none">powered by : <a href="http://www.xcomponent.com" target="_blank">XComponent</a></Label>
            </Box>
            <TextInput id="message" onKeyDown={ (evt) => {
                let code = evt.charCode || evt.keyCode;
                if (code === 13) {
                    sendMessage(evt.target.value);
                    evt.target.value = "";
                }
                }}
            />
    </Box>
);

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(AppFooter);