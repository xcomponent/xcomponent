import { addLocaleData } from "react-intl";
import * as localeData from "locales/data.json";
import * as en from "react-intl/locale-data/en";
import * as fr from "react-intl/locale-data/fr";

export const getLocalizedResources = () => {
    addLocaleData([...en, ...fr]);

    const language = navigator.language;

    const languageWithoutRegionCode = language.toLowerCase().split(/[_-]+/)[0];
    const messages = localeData[languageWithoutRegionCode] || localeData[language] || (<any>localeData).en;

    return messages;
};