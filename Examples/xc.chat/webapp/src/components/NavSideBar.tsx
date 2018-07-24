import * as React from "react";
import * as Sidebar from "grommet/components/SideBar";
import * as Menu from "grommet/components/Menu";
import * as Header from "grommet/components/Header";
import * as Anchor from "grommet/components/Anchor";
import * as Footer from "grommet/components/Footer";
import * as CloseIcon from "grommet/components/icons/base/Close";
import * as ChatIcon  from "grommet/components/icons/base/Chat";
import * as Title from "grommet/components/Title";
import * as AddCircleIcon from "grommet/components/icons/base/AddCircle";
import { connect } from "react-redux";
import * as Button from "grommet/components/Button";
import { Link } from "react-router";
import Logo from "components/Logo";
import { navActivate, selectRoomEvent, roomCreation } from "actions";
import { FormattedMessage } from "react-intl";
import { Room } from "reducers/rooms";

const mapStateToProps = (state, ownProps) => {
    return {
        connected: state.chatRoom.settings.login !== "" && state.chatRoom.selectedRoom !== null,
        rooms: state.chatRoom.availableRooms
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
        onClose: () => {
            dispatch(navActivate(false));
        },
        onClick: (room) => {
            dispatch(selectRoomEvent(room.name));
        },
        onCreateRoom: () => {
            dispatch(roomCreation(true));
        }
    };
};

const NavSideBar = ({ onClose, onClick, onCreateRoom, rooms, connected }) => {

    let roomLinks = [];

    if (rooms) {
        roomLinks.push(
            Array.from(rooms).map((room: Room) => {
                return (
                    <Button key={room.name} icon={<ChatIcon />} onClick={() => onClick(room)} plain={true} label={"#" + room.name} />
                );
            })
        );
    }

    let footer;

    if (connected) {
        footer = <Footer pad={{horizontal: "medium", vertical: "small"}}>
                <Button icon={<AddCircleIcon />} onClick={onCreateRoom} plain={true}/>
            </Footer>;
    }

    return (
        <Sidebar fixed={true} colorIndex="neutral-1">
            <Header size="large" justify="between" pad={{ horizontal: "medium" }}>
                <Title onClick={onClose} a11yTitle={"Close"}>
                    <Logo colorIndex="light-1" />
                    <FormattedMessage id="app.menu" />
                </Title>
                <Button icon={<CloseIcon />} onClick={onClose} plain={true}
                    a11yTitle={"Close"} />
            </Header>
            <Menu fill={true} primary={true}>
                {roomLinks}
            </Menu>
            {footer}
        </Sidebar>
    );
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(NavSideBar);
