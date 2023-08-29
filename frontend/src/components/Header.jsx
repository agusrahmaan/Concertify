import { Link } from "react-router-dom";

export default function Header() {
  return (
    <div>
      <div className="bg-slate-900 p-5 flex flex-row justify-between text-cyan-500 shadow-md shadow-black sticky">
        <Link to={"/"}>
          <p className="text-xl font-bold">CONCERTIFY</p>
        </Link>
        <button className="text-xl font-bold mr-7 text-right">Login</button>
      </div>
    </div>
  );
}
