import getGoogleOAuthURL from "@/functions/googleOAuth";
import { Button } from "@/components/ui/button";
import logo from "@/assets/DiffC.svg";
import Image from "next/image";
import GoogleIcon from "@/assets/googleicon.svg";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";

export default function Login() {
  return (
    <div>
      <Card className="w-[350px]">
        <CardHeader>
          <Image src={logo} alt="logo" />
          {/* <CardTitle>Create project</CardTitle>
          <CardDescription>
            Deploy your new project in one-click.
          </CardDescription> */}
        </CardHeader>
        <CardContent>
          <div className="grid w-full items-center gap-4">
            <EmailForm />

            <div className="flex justify-between items-center">
              <Separator className="w-2/5" />
              <p className="text-center">Or</p>
              <Separator className="w-2/5" />
            </div>

            <Button variant="outline" className="w-ful">
              <a
                href={getGoogleOAuthURL()}
                className=" flex items-center gap-2"
              >
                <Image src={GoogleIcon} alt="goole icon" className="w-7" />
                <p className="text-sm text-primar">Sign In with Google</p>
              </a>
            </Button>
          </div>
        </CardContent>
      </Card>
    </div>
  );
}

import * as React from "react";
import { Separator } from "../ui/separator";
import { EnvelopeOpenIcon } from "@radix-ui/react-icons";
import EmailForm from "./EmailForm";
