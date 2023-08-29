import { useState } from "react";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { MdLocationOn } from "react-icons/md";
import { SlCalender } from "react-icons/sl";
import { Link } from "react-router-dom";
import { AiOutlineDollar } from "react-icons/ai";
import { GrFormAdd } from "react-icons/gr";

export default function DetailConcert() {
  const [detail, setDetail] = useState([]);
  const { id } = useParams();

  useEffect(() => {
    fetch(`http://localhost:5000/api/Concert/${id}`)
      .then((response) => response.json())
      .then((detail) => setDetail(detail));
  }, [id]);

  return (
    <main className="bg-slate-800 ">
      {detail ? (
        <div className="flex flex-col">
          <div className="flex flex-row gap-10 p-10 justify-center ">
            <div className="border rounded-xl bg-gray-600 p-5 border-cyan-500 shadow-md shadow-cyan-500 w-[60%] ">
              <h1 className="text-6xl text-cyan-500 font-bold text-center p-3">
                {detail.musisi}
              </h1>
              <div className="flex flex-col gap-5 md:flex-row">
                <img
                  className="w-80 h-96 rounded-md"
                  src={detail.image}
                  alt={detail.musisi}
                />
                <div className="flex flex-col gap-5">
                  <p className="text-justify">{detail.description}</p>
                  <p className="flex flex-row gap-3 items-center font-bold">
                    <MdLocationOn size={24} />
                    {detail.venue}
                  </p>
                  <p className="flex flex-row gap-3 items-center">
                    <SlCalender size={24} />
                    {detail.date}
                  </p>
                  <div className="flex flex-row gap-5">
                    <button className="bg-blue-600 rounded-md w-fit px-7 py-3 flex flex-row items-center font-bold">
                      <GrFormAdd size={20} />
                      Add Wishlist
                    </button>
                    <button className="bg-amber-400 rounded-md w-fit px-7 py-3 flex flex-row items-center font-bold">
                      <AiOutlineDollar size={20} />
                      BUY
                    </button>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div className="flex justify-center p-5">
            <Link to={"/"}>
              <button className="bg-cyan-300 rounded-md w-fit px-7 py-2">
                BACK
              </button>
            </Link>
          </div>
        </div>
      ) : (
        "Loading..."
      )}
    </main>
  );
}
