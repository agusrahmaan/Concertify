import { useState } from "react";
import gambar from "../../public/concert.jpg";
import { useEffect } from "react";
import { Link } from "react-router-dom";
import { ImMusic } from "react-icons/im";
import { GiMicrophone } from "react-icons/gi";
import { GiThreeFriends } from "react-icons/gi";
import { useOutletContext } from "react-router-dom";

export default function Home() {
  const [concert, setConcert] = useState([]);

  useEffect(() => {
    fetch("http://localhost:5000/api/Concert")
      .then((response) => response.json())
      .then((concerts) => setConcert(concerts));
  }, []);

  return (
    <div className="bg-slate-800">
      <div className="">
        <img className="w-full" src={gambar} alt="" />
        <p className="font-bold mt-[-250px] pb-[140px] text-5xl text-center text-white italic decoration-slate-700 md:mt-[-550px] md:pb-[500px]">
          Lets sing with your favorite singer!!!
        </p>
      </div>
      <p className="text-xl m-5 text-center font-extrabold text-cyan-500">
        SEE LIST OF SOLO CONCERTS
      </p>
      <div className="flex flex-col flex-wrap gap-10 items-center pt-5 pb-5 md:flex-row md:justify-center">
        {concert.map((concert) => (
          <div
            key={concert.id}
            className="w-1/3 bg-gray-600 rounded-md p-2 flex flex-row flex-wrap gap-10 cursor-pointer hover:border-4 border-cyan-500 shadow-md shadow-cyan-500 md:items-center"
          >
            <img
              className="w-52 h-64 rounded-md "
              src={concert.image}
              alt={concert.musisi}
            />
            <Link to={`Concert/${concert.id}`}>
              <h3 className="font-bold text-xl ">{concert.musisi}</h3>
            </Link>
          </div>
        ))}
      </div>
    </div>
  );
}
