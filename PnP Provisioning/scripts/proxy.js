//@ts-check

const CertificateStore = require('@microsoft/gulp-core-build-serve/lib/CertificateStore');
const RestProxy = require('sp-rest-proxy');
const { join } = require('path');

const { privateConfigPath, proxyPort } = require(join(process.cwd(), './scripts/config.json'));

new RestProxy({
  port: proxyPort,
  configPath: join(process.cwd(), privateConfigPath),
  protocol: 'https',
  ssl: {
    cert: CertificateStore.default.instance.certificateData,
    key: CertificateStore.default.instance.keyData
  }
}).serve();