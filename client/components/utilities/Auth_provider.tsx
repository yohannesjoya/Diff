"use client";
import { SessionProvider } from "next-auth/react";
import React from "react";

interface ProviderProps {
  children: React.ReactNode;
  session?: any;
}

const AuthProvider: React.FC<ProviderProps> = ({ children, session }) => {
  return <SessionProvider session={session}>{children}</SessionProvider>;
};

export default AuthProvider;
