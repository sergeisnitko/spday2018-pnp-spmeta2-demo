//@ts-check

const { join } = require('path');

const { privateConfigPath } = require(join(process.cwd(), './scripts/config.json'));
const { siteUrl } = require(join(process.cwd(), privateConfigPath));
const serveJson = require(join(process.cwd(), './config/serve.json'));

const serveConfig = ({ build }) => {

  Object.keys(serveJson.serveConfigurations).forEach(key => {
    serveJson.serveConfigurations[key].pageUrl =
      serveJson.serveConfigurations[key].pageUrl.replace('{siteUrl}', siteUrl);
  });

  build.serve.setConfig(serveJson);

};

module.exports = { serveConfig };