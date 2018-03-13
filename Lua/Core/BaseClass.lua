require "Core/object"
BaseClass = class("BaseClass",nil)

function BaseClass:ctor()

end

function BaseClass:TableToStr(obj)
	-- body
	local lua = ""  
    local t = type(obj)  
    if t == "number" then  
        lua = lua .. obj  
    elseif t == "boolean" then  
        lua = lua .. tostring(obj)  
    elseif t == "string" then  
        lua = lua .. string.format("%q", obj)  
    elseif t == "table" then  
        lua = lua .. "{\n"  
    for k, v in pairs(obj) do  
        lua = lua .. "[" .. self:TableToStr(k) .. "]=" .. self:TableToStr(v) .. ",\n"  
    end  
    local metatable = getmetatable(obj)  
        if metatable ~= nil and type(metatable.__index) == "table" then  
        for k, v in pairs(metatable.__index) do  
            lua = lua .. "[" .. self:TableToStr(k) .. "]=" .. self:TableToStr(v) .. ",\n"  
        end  
    end  
        lua = lua .. "}"  
    elseif t == "nil" then  
        return nil  
    else  
        error("can not TableToStr a " .. t .. " type.")  
    end  
    return lua  
end

function BaseClass:StrToTable(str)
	-- body
	if str == nil or type(str) ~= "string" then
        return
    end
    
    return loadstring("return " .. str)()
end

function BaseClass:ToStringEx(value)
	-- body
	if type(value)=='table' then
       return self:TableToStr(value)
    elseif type(value)=='string' then
        return self:StrToTable(value)
    else
       return tostring(value)
    end
end

return BaseClass