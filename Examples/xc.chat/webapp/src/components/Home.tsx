import * as React from "react";
import * as Label from "grommet/components/Label";
import { connect } from "react-redux";
import PageHeader from "components/PageHeader";
import ChatRoom from "components/ChatRoom";
import * as Box from "grommet/components/Box";
import * as Form from "grommet/components/Form";
import * as Header from "grommet/components/Header";
import * as Heading from "grommet/components/Heading";
import * as Footer from "grommet/components/Footer";
import * as FormFields from "grommet/components/FormFields";
import * as Button from "grommet/components/Button";
import * as FormField from "grommet/components/FormField";
import * as TextInput from "grommet/components/TextInput";
import * as NumberInput from "grommet/components/NumberInput";
import { FormattedDate, FormattedMessage, defineMessages, injectIntl, InjectedIntl } from "react-intl";
import { connectEvent } from "actions";

interface HomeProps {
    intl: InjectedIntl;
}

const mapStateToProps = (state, ownProps) => {
    return {
        selectedRoom: state.chatRoom.selectedRoom ? state.chatRoom.selectedRoom.name : "",
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
        onClick: (host: string, port: number, login: string) => {
            dispatch(connectEvent(host, port, login));
        }
    };
};

const Home = ({ selectedRoom, onClick }) => {
    if (selectedRoom !== "") {
        return (
            <div>
                <PageHeader title={"#" + selectedRoom} />
                <ChatRoom/>
            </div>
        );
    }
    else {
        return (
            <Box>
                <PageHeader title="Login" />
                <Box align="center">
                    <Form>
                        <Header>
                            <Heading></Heading>
                        </Header>
                        <FormFields>
                            <FormField label="Host">
                                <TextInput name="host" defaultValue="localhost"/>
                            </FormField>
                            <FormField label="Port">
                                <NumberInput name="port" defaultValue={9443}/>
                            </FormField>
                            <FormField label="Login">
                                <TextInput name="login" defaultValue="User"/>
                            </FormField>
                        </FormFields>
                        <Footer pad={{"vertical": "medium"}}>
                            <Button align="center" label="Connect" primary={true} onClick={ (evt) => {
                                let host = (document.querySelector("[name=host]") as TextInput).value;
                                let port = (document.querySelector("[name=port]") as NumberInput).value;
                                let login = (document.querySelector("[name=login]") as TextInput).value;
                                onClick(host, port, login);
                                }}/>
                        </Footer>
                    </Form>
                </Box>
            </Box>
        );
    }
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(Home);