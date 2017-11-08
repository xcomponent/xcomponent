import * as React from "react";
import { connect } from "react-redux";
import * as Label from "grommet/components/Label";
import * as Layer from "grommet/components/Layer";
import * as Box from "grommet/components/Box";
import * as Header from "grommet/components/Header";
import * as Heading from "grommet/components/Heading";
import * as Title from "grommet/components/Title";
import * as TextInput from "grommet/components/TextInput";
import * as Button from "grommet/components/Button";
import { FormattedDate, FormattedMessage, defineMessages, injectIntl, InjectedIntl } from "react-intl";
import { roomCreation } from "actions";
import { createRoom } from "communication";

const mapStateToProps = (state, ownProps) => {
    return {
        onClick: (roomName: string, host: string, port: number) => {
            if (roomName && roomName !== "") {
                createRoom(roomName, state.chatRoom.settings.host, state.chatRoom.settings.port);
            }
        }
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
        onClose: () => {
            dispatch(roomCreation(false));
        }
    };
};

const CreateRoomLayer = ({ onClose, onClick }) => {
    return (
        <Layer closer={true} onClose={onClose}>            
            <Box pad="medium">
                <Title>
                    <FormattedMessage id="Create Room" />
                </Title>

                <form>
                    <table style={{ paddingTop: "15px" }}>
                        <tbody>
                            <tr>
                                <td style={{ paddingTop: "9px", paddingBottom: "9px", width: "40%" }}>
                                    <div>Roome Name</div>
                                </td>
                                <td style={{ width: "60%" }}>
                                    <TextInput placeHolder="Room Name" name="roomName"
                                    />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <Box direction="row" justify="end">
                        <Button
                            plain={false}
                            primary={true}
                            label="Create"
                            onClick={ (evt) => {
                                let roomName = (document.querySelector("[name=roomName]") as TextInput).value;
                                onClick(roomName);
                                onClose();
                            }}
                        />
                    </Box>
                </form>
            </Box>
        </Layer>
    );
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(injectIntl(CreateRoomLayer));