import gambar from "../../public/concert.jpg";

export default function Home() {
  return (
    <div>
      <img className="w-full" src={gambar} alt="" />
      <div>
        <p className="text-5xl font-bold text-center text-white">
          Enjoy your happiness by watching the concert
        </p>
      </div>
    </div>
  );
}
