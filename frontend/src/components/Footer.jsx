import { AiFillInstagram } from "react-icons/ai";
import { AiFillGithub } from "react-icons/ai";
import { AiFillMail } from "react-icons/ai";

export default function Footer() {
  return (
    <div className="bg-slate-900 p-10 text-cyan-500">
      <div className="flex flex-row gap-3 justify-center">
        <AiFillInstagram size={24} />
        <AiFillGithub size={24} />
        <AiFillMail size={24} />
      </div>
      <p className="text-center text-xs font-bold">&copy; CONCERTIFY 2023</p>
    </div>
  );
}
