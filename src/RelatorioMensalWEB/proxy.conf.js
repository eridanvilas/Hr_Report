const PROXY_CONFIG = [
    {
        context: ['/api'],
        target: 'https://localhost:44375/',
        secure: true,
        logLevel: 'debug',
        // pathRewrite:{'^/api': ''}
    }
];

module.exports = PROXY_CONFIG;