const PROXY_CONFIG = [
    {
        context: ['/api'],
        target: 'https://localhost:44374/',
        secure: true,
        logLevel: 'debug',
        // pathRewrite:{'^/api': ''}
    }
];

module.exports = PROXY_CONFIG;