using UnityEngine;

public enum GestureType
{
    None,

    // Cooking
    Chop,       // cắt — swipe xuống
    Stir,       // khuấy — vòng tròn
    Pinch,      // nêm — chụm ngón
    Knead,      // nhào — ép 2 tay
    Toss,       // lật — hất lên

    // Combat
    Fist,       // đấm — nắm tay
    Push,       // đẩy — 2 tay đẩy ra
    Circle,     // tornado — vòng tròn
    Slash,      // chém — swipe ngang
    Summon      // triệu hồi — 2 tay nâng lên
}
