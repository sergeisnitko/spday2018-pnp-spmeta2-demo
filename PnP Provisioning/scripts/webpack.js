//@ts-check

const webpack = require('webpack');
const { join } = require('path');

const { privateConfigPath, proxyPort } = require(join(process.cwd(), './scripts/config.json'));
const { siteUrl } = require(join(process.cwd(), privateConfigPath));
const webRelativeUrl = `/${siteUrl.split('/').splice(3, 100).join('/')}`;

const configureWebpack = ({ build }) => {
  build.configureWebpack.mergeConfig({
    additionalConfiguration: config => {

      // Load SCSS
      config.module.rules.push({
        test: /\.scss$/,
        use: [
          'style-loader',
          {
            loader: "css-loader",
            options: {
              minimize: true,
              sourceMap: true
            }
          },
          {
            loader: "sass-loader",
            options: {
              sourceMap: true
            }
          }
        ]
      });

      // Environment settings
      if (process.env.NODE_ENV === 'dev') {
        console.log('*********** Applying development settings to webpack ***********');
        const defineOptions = {
          '_ProxyHostUrl_': JSON.stringify(`https://localhost:${proxyPort}`),
          '_ProxyWebRelativeUrl_': JSON.stringify(webRelativeUrl)
        };
        config.plugins.push(new webpack.DefinePlugin(defineOptions));
      }

      return config;
    }
  });
};

module.exports = { configureWebpack };