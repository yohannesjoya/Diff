import type { Metadata } from "next";
import "./globals.css";
import { ThemeProvider } from "@/components/utilities/Theme_provider";
import { ModeToggle } from "@/components/utilities/Mode_toggle";
import { Toaster } from "@/components/ui/toaster";

export const metadata: Metadata = {
  title: "Difference",
  description: "Wait, We will show you the difference!",
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en" suppressHydrationWarning>
      <body>
        <ThemeProvider
          attribute="class"
          defaultTheme="system"
          enableSystem
          disableTransitionOnChange
        >
          <ModeToggle />

          {children}
        </ThemeProvider>
        <Toaster />
      </body>
    </html>
  );
}
