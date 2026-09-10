# Security Policy

## Supported Versions

OpenERP is currently under active development.

Because the project is still evolving, security support may primarily focus on the latest version available in the repository.

| Version                    | Supported      |
| -------------------------- | -------------- |
| Latest development version | ✅              |
| Older versions             | ⚠️ Best effort |

## Reporting a Vulnerability

Please **do not publicly disclose security vulnerabilities through GitHub Issues, discussions, or pull requests**.

If you discover a potential security vulnerability, report it privately to the project maintainers.

A security report should include:

* A clear description of the vulnerability
* Steps to reproduce the issue
* The affected component
* The potential impact
* Any proof of concept, if available
* Suggested mitigation, if known

Please avoid including sensitive personal information, credentials, production secrets, or real customer data in your report.

## Examples of Security Issues

Security issues may include:

* Authentication bypass
* Authorization vulnerabilities
* SQL injection
* Cross-site scripting
* Sensitive information disclosure
* Insecure API endpoints
* Broken access controls
* Credential exposure
* Insecure file handling
* Server-side request forgery
* Dependency vulnerabilities
* Improper handling of sensitive business information

## What Not to Report Publicly

Do not publicly post:

* Passwords
* API keys
* Access tokens
* Database credentials
* Private connection strings
* Private employee information
* Customer information
* Production secrets
* Detailed exploit instructions for an unresolved vulnerability

## Responsible Disclosure

We ask security researchers and contributors to give maintainers reasonable time to investigate and address vulnerabilities before publicly disclosing them.

The project maintainers will make reasonable efforts to:

1. Confirm the reported vulnerability.
2. Investigate its impact.
3. Develop an appropriate fix.
4. Release the fix when practical.
5. Communicate relevant information to affected users.

## Security Best Practices for Contributors

Contributors should:

* Never commit secrets to the repository.
* Use environment-specific configuration for sensitive values.
* Avoid hardcoding credentials.
* Validate and sanitize external input.
* Use parameterized database queries.
* Keep dependencies updated.
* Follow least-privilege principles.
* Avoid exposing sensitive information through API responses or logs.
* Add tests for security-sensitive functionality.

## Production Disclaimer

OpenERP is an open-source project under active development.

Before deploying OpenERP in production, organizations should perform their own:

* Security review
* Penetration testing
* Dependency assessment
* Configuration review
* Access-control review
* Data-protection assessment

The project should not be assumed to be production-ready solely because a feature or release is available.
s