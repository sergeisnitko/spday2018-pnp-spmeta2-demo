//@ts-check

const { join } = require('path');
const { AuthConfig } = require('node-sp-auth-config');

const { privateConfigPath } = require(join(process.cwd(), './scripts/config.json'));
const args = process.argv.splice(3);

const forcePrompts = args.indexOf('--force') !== -1;

const authConfig = new AuthConfig({
  configPath: join(process.cwd(), privateConfigPath),
  encryptPassword: true,
  saveConfigOnDisk: true,
  forcePrompts
});

authConfig.getContext().catch(console.log);
