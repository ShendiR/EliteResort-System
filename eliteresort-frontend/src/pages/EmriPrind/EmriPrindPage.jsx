import React, { useState, useEffect } from "react";
import api from "../../api/axiosInstance";

const EmriPrindPage = () => {
  const [data, setData] = useState([]);
  const [form, setForm] = useState({ id: 0, emri: "", pershkrimi: "" });

  const refreshData = async () => {
    try {
      const res = await api.get("/EmriPrind");
      setData(res.data);
    } catch (err) {
      console.error("Error ne API", err);
    }
  };

  useEffect(() => {
    // eslint-disable-next-line react-hooks/set-state-in-effect
    refreshData();
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      if (form.id === 0) {
        await api.post("/EmriPrind", {
          emri: form.emri,
          pershkrimi: form.pershkrimi,
        });
      } else {
        await api.put(`/EmriPrind/${form.id}`, form);
      }
      setForm({ id: 0, emri: "", pershkrimi: "" });
      refreshData();
    // eslint-disable-next-line no-unused-vars
    } catch (err) {
      alert("Gabim gjate ruajtjes!");
    }
  };

  const handleDelete = async (id) => {
    if (window.confirm("A jeni te sigurt?")) {
      await api.delete(`/EmriPrind/${id}`);
      refreshData();
    }
  };

  return (
    <div className="p-6 bg-white rounded-xl shadow-sm">
      <h1 className="text-2xl font-bold text-slate-800 mb-6">
        Menaxhimi Fluturimeve
      </h1>
      <form
        onSubmit={handleSubmit}
        className="mb-10 p-4 border border-slate-200 rounded-lg bg-slate-50"
      >
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
          <input
            className="p-2 border rounded text-black"
            placeholder="Emri fluturimit"
            value={form.emri}
            onChange={(e) => setForm({ ...form, emri: e.target.value })}
            required
          />
          <input
            className="p-2 border rounded text-black"
            placeholder="Numri i fluturimit"
            value={form.pershkrimi}
            onChange={(e) => setForm({ ...form, pershkrimi: e.target.value })}
          />
        </div>
        <button
          type="submit"
          className="mt-4 bg-amber-600 text-white px-6 py-2 rounded-lg hover:bg-amber-700"
        >
          {form.id === 0 ? "Shto" : "Ruaj"}
        </button>
      </form>
      <table className="w-full text-left">
        <thead>
          <tr className="border-b text-slate-400 text-sm uppercase">
            <th className="p-3">Emri</th>
            <th className="p-3">Pershkrimi</th>
            <th className="p-3 text-right">Aksionet</th>
          </tr>
        </thead>
        <tbody>
          {data.map((item) => (
            <tr key={item.id} className="border-b hover:bg-slate-50">
              <td className="p-3 font-medium text-black">{item.emri}</td>
              <td className="p-3 text-slate-500">{item.pershkrimi}</td>
              <td className="p-3 text-right">
                <button
                  onClick={() => setForm(item)}
                  className="text-amber-600 mr-4 font-bold"
                >
                  Edit
                </button>
                <button
                  onClick={() => handleDelete(item.id)}
                  className="text-red-500 font-bold"
                >
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default EmriPrindPage;