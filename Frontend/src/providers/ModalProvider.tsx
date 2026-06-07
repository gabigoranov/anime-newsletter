import { useState, type ReactNode } from "react";
import { ModalContext } from "../contexts/ModalContext";


export function ModalProvider({ children }: { children: ReactNode }) {
  const [isSignupOpen, setIsSignupOpen] = useState(false);
  const [signupEmail, setSignupEmail] = useState("");

  const openSignup = (email?: string) => {
    setSignupEmail(email || ""); // Set email if provided, otherwise clear it
    setIsSignupOpen(true);
  };

  const closeSignup = () => setIsSignupOpen(false);

  return (
    <ModalContext.Provider
      value={{
        isSignupOpen,
        openSignup,
        closeSignup,
        signupEmail,
      }}
    >
      {children}
    </ModalContext.Provider>
  );
}
