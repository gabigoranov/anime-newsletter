import { createContext } from "react";

type ModalContextType = {
  isSignupOpen: boolean;
  openSignup: (email?: string) => void;
  closeSignup: () => void;
  signupEmail: string;
};

export const ModalContext = createContext<ModalContextType | undefined>(undefined);


