using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class uService
{
    public static string m_host = "http://127.0.0.1";
    public static string m_url_register = "/e5/register.php";/// <summary> /// đăng ký /// </summary>
	public static string m_url_login = "/e5/login.php";/// <summary> /// đăng nhập /// </summary>
    public static string m_url_login_fb = "/e5/login_fb.php";/// <summary> /// login bằng facebook /// </summary>
	public static string m_url_character_origin = "/e5/character_origin.php";/// <summary> /// load danh sách nv mẫu /// </summary>
	public static string m_url_danh_hieu_origin = "/e5/danh_hieu_origin.php";/// <summary> /// load danh sách danh hiệu /// </summary>
	public static string m_url_country_origin = "/e5/country_origin.php";/// <summary> /// load danh sách quốc gia /// </summary>
	public static string m_url_level_origin = "/e5/level_origin.php";/// <summary> /// load danh sách level /// </summary>	
	public static string m_url_sms_offline_origin = "/e5/sms_offline_origin.php";/// <summary> /// load danh sách tin nhắn offline của người chơi /// </summary>	
	public static string m_url_friend_invite_origin = "/e5/friend_invite_origin.php";/// <summary> /// load danh sách mời kết bạn /// </summary>
	public static string m_url_bh_invite_origin = "/e5/bh_invite_origin.php";/// <summary> /// load danh sách thư xin vào bang hội/// </summary>
	public static string m_url_bh_invited_origin = "/e5/bh_invited_origin.php";/// <summary> /// load danh sách other mời vào bang hội/// </summary>
	public static string m_url_bh_inviter_origin = "/e5/bh_inviter_origin.php";/// <summary> /// load danh sách thư mời người khác vào bang hội/// </summary>
	public static string m_url_bh_origin = "/e5/bh_origin.php";/// <summary> /// load danh sách bang hội đã có trong hệ thống/// </summary>
	public static string m_url_chat_invalid = "/e5/chat_invalid_origin.php";/// <summary> /// load danh sách ~ từ khóa chat không hợp lệ/// </summary>
	public static string m_url_character_create = "/e5/character_create.php";/// <summary> /// tạo class nv/// </summary>
    public static string m_url_character_check_name = "/e5/character_check_name.php";/// <summary> /// kiểm tra tên nv có tồn tại k & lưu vào hệ thống nếu k tồn tại/// </summary>
    public static string m_url_td_mqh_ngu_hanh = "/e5/td_mqh_ngu_hanh.php";/// <summary> /// load moi quan he ngu hanh/// </summary>
    public static string m_url_combo_anim = "/e5/combo_anim.php";/// <summary> /// load animation cua moi loai combo ( 1..7 )/// </summary>
    public static string m_url_spell_origin = "/e5/spell_origin.php";/// <summary> /// load danh sách spell mẫu /// </summary>
    public static string m_url_character_spell = "/e5/user_spell.php";/// <summary> /// load danh sách user spell/// </summary>
    public static string m_url_update_character_spell = "/e5/update_user_spell.php";/// <summary> /// load danh sách user spell/// </summary>

    public static string m_url_combo = "/e5/combo.php";/// <summary> /// load info cua moi loai combo /// </summary>
	public static string m_url_user_combo = "/e5/user_combo.php";/// <summary> /// load user combo /// </summary>

    public static string m_url_user_get_info = "/e5/user_get_info.php";/// <summary> /// load thông tin của friend/// </summary>
    public static string m_url_friend_add = "/e5/friend_add.php";/// <summary> /// add friend/// </summary>

    public static string m_url_friend_update_by_type = "/e5/friend_update_by_type.php";/// <summary> /// update friend by type/// </summary>
    public static string m_url_friend_update_all_type = "/e5/friend_update_all_type.php";/// <summary> /// update all friend type/// </summary>
    public static string m_url_friend_add_normal = "/e5/friend_add_normal.php";/// <summary> /// add friend normal/// </summary>
    public static string m_url_friend_remove = "/e5/friend_remove.php";/// <summary> /// remove friend/// </summary>

    public static string m_url_update_user_combo_all = "/e5/update_user_combo.php";/// <summary> /// update user combo in database/// </summary>
    public static string m_url_update_user_combo_slot = "/e5/update_user_combo_slot.php";/// <summary> /// update/// </summary>
    public static string m_url_character_inventory = "/e5/character_inventory.php";/// <summary> /// load chacracter inventory/// </summary>
    public static string m_url_clothes = "/e5/clothes.php";/// <summary> /// load clothes/// </summary>
    public static string m_url_character10stats = "/e5/character_10stats.php";/// <summary> /// load user stats/// </summary>


    public static IEnumerator request(string url, Dictionary<string, string> paras
        , System.Action<string> cb_fail, System.Action<string> cb_success)
    {

        WWWForm form = new WWWForm();

        foreach (string key in paras.Keys)
        {
            form.AddField(key, paras[key]);
        }

        WWW w = new WWW(url, form);

        yield return w;

        requestCB(w, cb_fail, cb_success);

    }

    public static IEnumerator request(string url, System.Action<string> cb_fail, System.Action<string> cb_success)
    {


        WWW w = new WWW(url);

        yield return w;

        requestCB(w, cb_fail, cb_success);

    }

    static void requestCB(WWW w, System.Action<string> cb_fail, System.Action<string> cb_success)
    {
        if (w.error != null)
        {
            //Debug.Log (w.error);
            if (cb_fail != null)
            {
                cb_fail(w.error);
            }
        }
        else
        {
            Debug.Log(w.text);
            if (w.text.Contains("s::0"))
            {
                if (cb_fail != null)
                {
                    cb_fail(w.text.Replace("s::0", ""));
                }
            }
            else
            {
                if (cb_success != null)
                {
                    cb_success(w.text.Replace("s::1", ""));
                }
            }
        }
    }

    public static void setHost(string host_ip)
    {
        m_host = "http://" + host_ip;
    }

    public static string url_register()
    {
        return m_host + m_url_register;
    }
}
