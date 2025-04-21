# TF_ACADEMY_STUDENT_MANAGEMENT_APP
ASP.NET MVC front-end Web App for a student management system

# Authentication in the Student Management Application

This document outlines the authentication process implemented in the Student Management Application. The application utilizes a secure and industry-standard approach to verify the identity of users before granting access to its features and data.

## Overview

The application employs **Google OAuth 2.0** for user authentication. This allows users to securely sign in using their existing Google accounts, eliminating the need to create and remember a separate set of credentials specifically for this application.

The authentication flow involves a collaboration between the frontend (user interface) and the backend (API).

## Authentication Flow

1.  **User Initiates Login:**
    * On the frontend's "Sign In" page, the user clicks the "Sign in with Google" button.
    * This action triggers a redirection to a specific endpoint on the backend API (`/login/google`). The frontend may optionally include a `returnUrl` as a query parameter to indicate where the user should be redirected after successful login.

2.  **Backend Initiates Google Authentication Challenge:**
    * The backend API receives the request to `/login/google`.
    * The backend's authentication controller action (`GoogleLogin`) initiates an OAuth 2.0 authentication challenge using the configured Google authentication scheme.
    * This process generates an authorization URL that directs the user to Google's sign-in page. The URL includes parameters such as the application's Client ID, the requested scopes (e.g., profile, email), a redirect URI (back to the backend), and a state parameter for security.

3.  **User Signs In with Google:**
    * The user's browser is redirected to Google's sign-in page.
    * The user enters their Google account credentials and grants (or denies) the application the requested permissions.

4.  **Google Redirects Back to Backend with Authorization Code:**
    * Upon successful authentication and authorization by the user, Google redirects the browser back to the backend API at the configured callback URL (`/signin-google`). This request includes an authorization code in the query parameters.

5.  **Backend Exchanges Authorization Code for Access and ID Tokens:**
    * The backend API receives the callback request with the authorization code.
    * The backend's authentication middleware (specifically the Google authentication handler) communicates directly with Google's token endpoint.
    * It exchanges the authorization code for an Access Token (used to access Google services on the user's behalf), an ID Token (containing user information), and potentially a Refresh Token (to obtain new access tokens without re-prompting the user).

6.  **Backend Creates User Session and Redirects to Frontend:**
    * The backend API validates the ID Token to verify the user's identity.
    * Upon successful validation, the backend establishes an authentication session for the user within the application. This is typically done by setting an authentication cookie in the user's browser.
    * The backend then constructs a redirect URL back to the frontend application, using the `returnUrl` provided initially by the frontend (or a default homepage URL if no `returnUrl` was provided). The browser is redirected to this frontend URL.

7.  **Frontend Receives Redirect and User is Authenticated:**
    * The user's browser navigates back to the frontend application.
    * The frontend can now rely on the authentication cookie set by the backend to recognize the user as authenticated for subsequent requests to the backend API.
    * The frontend may then display user-specific information or grant access to protected areas of the application.

## Technologies Used

* **Google OAuth 2.0:** The industry-standard protocol for delegated authorization.
* **ASP.NET Core Authentication Middleware:** Provides the framework for implementing various authentication schemes, including Google.
* **Cookies:** Used to maintain the authenticated session between the user's browser and the backend API.

## Security Considerations

* **HTTPS:** All communication involving authentication (between the frontend and backend, and between the backend and Google) is conducted over HTTPS to ensure the confidentiality and integrity of data in transit.
* **State Parameter:** The OAuth 2.0 flow utilizes a `state` parameter to prevent Cross-Site Request Forgery (CSRF) attacks. The
