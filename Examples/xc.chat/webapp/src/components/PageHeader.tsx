import * as React from "react";
import { connect } from "react-redux";
import * as Header from "grommet/components/Header";
import * as Box from "grommet/components/Box";
import * as Title from "grommet/components/Title";

interface PageHeaderProps {
    title: string;
}

const mapStateToProps = (state, ownProps: PageHeaderProps): PageHeaderProps => {
    return {
        title: ownProps.title,
    };
};

const PageHeader = ({title}: PageHeaderProps) => {
    return (
        <Header
            fixed={true}
            direction="row"
            justify="between"
            size="small"
            pad={{ horizontal: "medium" }} className="grommetux-box--separator-top">
            <Box direction="row">
                <Title>{title}</Title>
            </Box>
        </Header>
    );
};

export default connect(
    mapStateToProps
)(PageHeader);